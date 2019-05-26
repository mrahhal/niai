import 'package:flutter/material.dart';
import 'package:niai/models/models.dart';

class VocabView extends StatelessWidget {
  final Vocab vocab;

  const VocabView(
    this.vocab, {
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
      child: Text(vocab.kanji),
    );
  }
}
