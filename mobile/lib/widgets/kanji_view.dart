import 'package:flutter/material.dart';
import 'package:niai/models/models.dart';

class KanjiView extends StatelessWidget {
  final KanjiSummary kanji;
  final bool original;

  KanjiView(
    this.kanji, {
    this.original = false,
    Key key,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.all(8),
      decoration: BoxDecoration(
        color: Theme.of(context).cardColor,
        border: Border.all(width: 1),
        borderRadius: BorderRadius.all(Radius.circular(2)),
      ),
      child: Row(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: <Widget>[
          Container(
            padding: EdgeInsets.symmetric(horizontal: 4, vertical: 2),
            margin: EdgeInsets.only(right: 8),
            decoration: BoxDecoration(
              border: Border.all(width: 2),
              borderRadius: BorderRadius.all(Radius.circular(2)),
            ),
            child: Text(
              kanji.character,
              style: TextStyle(fontSize: 30),
            ),
          ),
          Flexible(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: <Widget>[
                Text(kanji.meanings.join(', ')),
                Text(kanji.onyomi ?? ''),
                Text(kanji.kunyomi ?? ''),
              ],
            ),
          )
        ],
      ),
    );
  }
}
