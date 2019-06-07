import 'package:flutter/material.dart';

class NiaiInherited extends InheritedWidget {
  NiaiInherited({Key key, Widget child}) : super(key: key, child: child);

  static NiaiInherited of(BuildContext context) {
    return (context.inheritFromWidgetOfExactType(NiaiInherited)
        as NiaiInherited);
  }

  @override
  bool updateShouldNotify(NiaiInherited oldWidget) {
    return true;
  }
}
