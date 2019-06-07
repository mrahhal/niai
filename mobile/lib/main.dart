import 'package:dynamic_theme/dynamic_theme.dart';
import 'package:flutter/material.dart';
import 'package:niai/infrastructure/themes.dart';
import 'package:niai/pages/home_page.dart';
import 'package:niai/widgets/niai_inherited.dart';

void main() => runApp(MyApp());

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return DynamicTheme(
        defaultBrightness: Brightness.light,
        data: (brightness) =>
            brightness == Brightness.dark ? darkTheme : lightTheme,
        themedWidgetBuilder: (context, theme) {
          return MaterialApp(
            title: 'Niai',
            theme: theme,
            home: NiaiInherited(
              child: HomePage(),
            ),
          );
        });
  }
}
