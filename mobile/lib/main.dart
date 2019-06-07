import 'package:flutter/material.dart';
import 'package:niai/pages/home_page.dart';
import 'package:niai/widgets/niai_inherited.dart';

void main() => runApp(MyApp());

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Niai',
      theme: _buildTheme(),
      home: NiaiInherited(
        child: HomePage(),
      ),
    );
  }

  _buildTheme() {
    return ThemeData(
      // brightness: Brightness.dark,
      primarySwatch: Colors.green,
      backgroundColor: Colors.green[400],
    );
  }
}
