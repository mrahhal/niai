import 'package:flutter/material.dart';
import 'package:niai/models/models.dart';
import 'package:sticky_headers/sticky_headers.dart';

import 'kanji_view.dart';

class KanjiListView extends StatelessWidget {
  final Kanji kanji;

  const KanjiListView(
    this.kanji, {
    Key key,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return StickyHeader(
      header: Container(
        color: Theme.of(context).backgroundColor,
        padding: EdgeInsets.all(8),
        alignment: Alignment.centerLeft,
        child: Text(
          kanji.character,
          style: TextStyle(color: Colors.white),
        ),
      ),
      content: Column(
        children: <Widget>[
          _buildKanjiCard(kanji, true),
          for (var item in kanji.similar) _buildKanjiCard(item, false),
        ],
      ),
    );
  }

  _buildKanjiCard(KanjiSummary kanji, bool original) {
    return Container(
      margin:
          EdgeInsets.only(left: 8, top: original ? 8 : 0, right: 8, bottom: 8),
      child: KanjiView(kanji, original: original),
    );
  }
}
