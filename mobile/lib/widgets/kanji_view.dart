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
      child: Text(
        kanji.character,
        style: TextStyle(fontSize: 18),
      ),
    );
  }
}
