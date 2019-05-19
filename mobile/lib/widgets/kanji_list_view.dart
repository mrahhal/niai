import 'package:flutter/material.dart';
import 'package:niai/models/models.dart';

import 'kanji_view.dart';

class KanjiListView extends StatelessWidget {
  final Kanji kanji;

  const KanjiListView(
    this.kanji, {
    Key key,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.stretch,
      children: <Widget>[
        Container(
          padding: EdgeInsets.all(8),
          child: Text(kanji.character),
        ),
        KanjiView(kanji, original: true),
        for (var item in kanji.similar) KanjiView(item),
      ],
    );
  }
}
