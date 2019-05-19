import 'package:json_annotation/json_annotation.dart';

import 'kanji.dart';
import 'vocab.dart';

part 'search_result.g.dart';

@JsonSerializable()
class SearchResult {
  SearchResult();

  List<Kanji> kanjis;
  List<Vocab> homonyms;
  List<Vocab> synonyms;

  factory SearchResult.fromJson(Map<String, dynamic> json) =>
      _$SearchResultFromJson(json);

  Map<String, dynamic> toJson() => _$SearchResultToJson(this);
}
