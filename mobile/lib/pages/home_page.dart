import 'package:dynamic_theme/dynamic_theme.dart';
import 'package:flutter/material.dart';
import 'package:niai/models/search_result.dart';
import 'package:niai/services/api.dart';
import 'package:niai/widgets/kanji_list_view.dart';
import 'package:niai/widgets/vocab_view.dart';
import 'package:rxdart/rxdart.dart';

class HomePage extends StatefulWidget {
  HomePage({Key key}) : super(key: key);

  @override
  _HomePageState createState() => _HomePageState();
}

class _Example {
  final String text;
  final String example;

  _Example(this.text, this.example);
}

class _HomePageState extends State<HomePage> {
  Subject<String> _searchResultSubject = PublishSubject<String>();
  SearchResult _result;
  bool _loading = false;
  TextEditingController _searchController = TextEditingController();

  _HomePageState() {
    _searchResultSubject.switchMap((value) {
      if (value == '') return Observable.just(null);

      setState(() {
        _loading = true;
      });

      return Observable.fromFuture(
          api.search(value).catchError((o) => _result));
    }).listen((result) {
      setState(() {
        _loading = false;
        _result = result;
      });
    });
  }

  @override
  void initState() {
    super.initState();

    _searchController.addListener(() {
      _searchResultSubject.add(_searchController.text);
    });
  }

  void _onExampleTap(String value) {
    _searchController
      ..text = value
      ..selection = TextSelection.collapsed(offset: value.length);
  }

  @override
  Widget build(BuildContext context) {
    var currentBrightness = DynamicTheme.of(context).data.brightness;

    var examples = [
      _Example('Lookup several kanjis at the same time!', '枝方寄'),
      _Example('Lookup homonyms (same reading, different meaning)', 'かえる'),
      _Example('Lookup synonyms (similar meaning)', 'love'),
    ];

    return Scaffold(
      appBar: AppBar(
        // leading: DecoratedBox(
        //   decoration: BoxDecoration(
        //     image: DecorationImage(
        //       image: AssetImage('assets/logo.png'),
        //     ),
        //   ),
        // ),
        title: Text('Niai'),
      ),
      drawer: Drawer(
        child: ListView(
          children: <Widget>[
            DrawerHeader(
              decoration: BoxDecoration(color: Theme.of(context).primaryColor),
              child: DecoratedBox(
                decoration: BoxDecoration(
                  image: DecorationImage(
                    image: AssetImage('assets/logo.png'),
                  ),
                ),
              ),
            ),
            ListTile(
              leading: Icon(Icons.title),
              title: new Text(
                  currentBrightness == Brightness.dark ? 'Light' : 'Dark'),
              onTap: () {
                if (currentBrightness == Brightness.dark) {
                  DynamicTheme.of(context).setBrightness(Brightness.light);
                } else {
                  DynamicTheme.of(context).setBrightness(Brightness.dark);
                }

                Navigator.pop(context);
              },
            ),
          ],
        ),
      ),
      body: Column(
        children: <Widget>[
          Container(
            child: SizedBox(
              child: LinearProgressIndicator(value: _loading ? null : 0),
              height: 2,
            ),
          ),
          TextField(
            controller: _searchController,
            autofocus: true,
            decoration: InputDecoration(
              hintText: 'Search',
              prefixIcon: Icon(Icons.search),
            ),
          ),
          Expanded(
            child: _result != null
                ? ListView(
                    children: <Widget>[
                      for (var item in _result.synonyms) VocabView(item),
                      for (var item in _result.homonyms) VocabView(item),
                      for (var item in _result.kanjis) KanjiListView(item),
                    ],
                  )
                : Container(
                    margin: EdgeInsets.all(8),
                    child: ListView(
                      children: <Widget>[
                        Text(
                            'Just start typing to search for similar Kanjis, homonyms, and synonyms!'),
                        SizedBox(height: 16),
                        for (var example in examples)
                          Row(
                            children: <Widget>[
                              Text('${example.text} - '),
                              InkWell(
                                child: Text(example.example),
                                onTap: () {
                                  _onExampleTap(example.example);
                                },
                              )
                            ],
                          ),
                      ],
                    ),
                  ),
          ),
        ],
      ),
    );
  }
}
