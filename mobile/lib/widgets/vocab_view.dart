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
      child: Text(vocab.kanji),
    );
  }
}
