import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
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
    var allReadings =
        (kanji.onyomi == null ? '' : (kanji.onyomi + ', ')) + kanji.kunyomi;

    return InkWell(
      onTap: () {
        Clipboard.setData(new ClipboardData(text: kanji.character));

        Scaffold.of(context).showSnackBar(SnackBar(
          content: Text('Copied "${kanji.character}"'),
        ));
      },
      child: Container(
        child: Row(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: <Widget>[
            Container(
              padding: EdgeInsets.symmetric(horizontal: 8, vertical: 2),
              child: Text(
                kanji.character,
                style: TextStyle(fontSize: 30),
              ),
            ),
            Flexible(
              fit: FlexFit.tight,
              child: Container(
                padding: EdgeInsets.all(8),
                decoration: original
                    ? null
                    : BoxDecoration(
                        border: Border(
                          top: BorderSide(
                            width: 1,
                            color: Theme.of(context).dividerColor,
                          ),
                        ),
                      ),
                child: Row(
                  children: <Widget>[
                    Flexible(
                      fit: FlexFit.tight,
                      child: Container(
                        margin: EdgeInsets.only(right: 8),
                        child: Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: <Widget>[
                            Text(kanji.meanings.join(', ')),
                            Text(allReadings),
                          ],
                        ),
                      ),
                    ),
                    Column(
                      crossAxisAlignment: CrossAxisAlignment.end,
                      children: <Widget>[
                        if (kanji.grade != null) Text('G${kanji.grade}'),
                        if (kanji.jlpt != null) Text('N${kanji.jlpt}'),
                        if (kanji.waniKaniLevel != null)
                          Text('WK${kanji.waniKaniLevel}'),
                      ],
                    )
                  ],
                ),
              ),
            )
          ],
        ),
      ),
    );
  }
}
