import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:niai/models/models.dart';

class Api {
  Future<Metadata> getMetadata() async {
    final response = await http.get(_buildUrl(path: '/meta'));

    return Metadata.fromJson(json.decode(response.body));
  }

  Future<SearchResult> search(String q) async {
    final response =
        await http.get(_buildUrl(path: '/search', params: {'q': q}));

    return SearchResult.fromJson(json.decode(response.body));
  }

  _buildUrl({String path, dynamic params}) {
    return Uri.https('niai-api.mrahhal.net', 'api$path', params);
  }
}

Api api = Api();
