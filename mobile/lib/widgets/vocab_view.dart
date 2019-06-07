import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:niai/models/models.dart';

class VocabView extends StatelessWidget {
  final Vocab vocab;

  const VocabView(
    this.vocab, {
    Key key,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: () {
        Clipboard.setData(new ClipboardData(text: vocab.kanji));

        Scaffold.of(context).showSnackBar(SnackBar(
          content: Text('Copied "${vocab.kanji}"'),
        ));
      },
      child: Container(
        padding: EdgeInsets.all(8),
        decoration: BoxDecoration(
          border: Border(
              bottom:
                  BorderSide(width: 1, color: Theme.of(context).dividerColor)),
        ),
        child: Row(
          children: <Widget>[
            Text(
              vocab.kanji,
              style: TextStyle(fontSize: 20),
            ),
          ],
        ),
      ),
    );
  }
}
