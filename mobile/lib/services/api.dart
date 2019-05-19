import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:niai/models/metadata.dart';
import 'package:niai/models/search_result.dart';

class Api {
  Future<Metadata> getMetadata() async {
    final response = await http.get(_buildUrl(path: '/meta'));

    if (response.statusCode == 200) {
      return Metadata.fromJson(json.decode(response.body));
    } else {
      throw Exception('Failed to load metadata.');
    }
  }

  Future<SearchResult> search(String q) async {
    final response =
        await http.get(_buildUrl(path: '/search', params: {'q': q}));

    if (response.statusCode == 200) {
      return SearchResult.fromJson(json.decode(response.body));
    } else {
      throw Exception('Failed to load search result.');
    }
  }

  _buildUrl({String path, dynamic params}) {
    return Uri.http('api.niai.mrahhal.net', 'api$path', params);
  }
}
