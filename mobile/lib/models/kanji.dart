import 'package:json_annotation/json_annotation.dart';

part 'kanji.g.dart';

@JsonSerializable()
class KanjiSummary {
  KanjiSummary();

  String character;
  List<String> meanings;

  factory KanjiSummary.fromJson(Map<String, dynamic> json) =>
      _$KanjiSummaryFromJson(json);

  Map<String, dynamic> toJson() => _$KanjiSummaryToJson(this);
}

@JsonSerializable()
class KanjiSimilar extends KanjiSummary {
  KanjiSimilar();

  double score;

  factory KanjiSimilar.fromJson(Map<String, dynamic> json) =>
      _$KanjiSimilarFromJson(json);

  Map<String, dynamic> toJson() => _$KanjiSimilarToJson(this);
}

@JsonSerializable()
class Kanji extends KanjiSummary {
  Kanji();

  List<KanjiSimilar> similar;

  factory Kanji.fromJson(Map<String, dynamic> json) => _$KanjiFromJson(json);

  Map<String, dynamic> toJson() => _$KanjiToJson(this);
}
