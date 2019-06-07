import 'package:flutter/material.dart';
import 'package:niai/models/models.dart';

class TagView extends StatelessWidget {
  final Tag tag;

  TagView(
    this.tag, {
    Key key,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Text(tag.key),
    );
  }
}
