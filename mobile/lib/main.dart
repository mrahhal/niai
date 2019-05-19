import 'package:flutter/material.dart';
import 'package:niai/models/search_result.dart';
import 'package:niai/services/api.dart';
import 'package:rxdart/rxdart.dart';

import 'widgets/kanji_list_view.dart';
import 'widgets/vocab_view.dart';

void main() => runApp(MyApp());

var api = Api();

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Niai',
      theme: ThemeData(
        primarySwatch: Colors.indigo,
      ),
      home: HomePage(),
    );
  }
}

class HomePage extends StatefulWidget {
  HomePage({Key key}) : super(key: key);

  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  Subject<String> _searchResultSubject = PublishSubject<String>();
  SearchResult _result;

  _HomePageState() {
    _searchResultSubject.switchMap((value) {
      if (value == '') return Observable.just(null);
      return Observable.fromFuture(api.search(value));
    }).listen((result) {
      setState(() {
        _result = result;
      });
    });
  }

  void _onTextChange(String value) async {
    _searchResultSubject.add(value);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Niai'),
      ),
      body: Column(
        children: <Widget>[
          Padding(
            padding: EdgeInsets.all(0),
            child: TextField(
              autofocus: true,
              onChanged: _onTextChange,
              decoration: InputDecoration(
                hintText: 'Search',
                prefixIcon: Icon(Icons.search),
              ),
            ),
          ),
          Expanded(
            child: ListView(
              children: <Widget>[
                if (_result != null) ...<Widget>[
                  for (var item in _result.synonyms) VocabView(item),
                  for (var item in _result.homonyms) VocabView(item),
                  for (var item in _result.kanjis) KanjiListView(item),
                ],
              ],
            ),
          ),
        ],
      ),
    );
  }
}
