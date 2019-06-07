import 'package:json_annotation/json_annotation.dart';

import 'tag.dart';

part 'kanji.g.dart';

@JsonSerializable()
class KanjiSummary {
  KanjiSummary();

  String character;
  List<String> meanings;
  String onyomi;
  String kunyomi;
  int waniKaniLevel;
  List<Tag> tags;
  int frequency;
  int strokes;
  int jlpt;
  int grade;

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
