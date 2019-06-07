import 'package:json_annotation/json_annotation.dart';

import 'tag.dart';

part 'vocab.g.dart';

@JsonSerializable()
class Vocab {
  Vocab();

  String kanji;
  int frequency;
  List<VocabContextualMeaning> meanings;

  factory Vocab.fromJson(Map<String, dynamic> json) => _$VocabFromJson(json);

  Map<String, dynamic> toJson() => _$VocabToJson(this);
}

@JsonSerializable()
class VocabContextualMeaning {
  VocabContextualMeaning();

  String kanji;
  String kana;
  List<String> meanings;
  List<Tag> tags;

  factory VocabContextualMeaning.fromJson(Map<String, dynamic> json) =>
      _$VocabContextualMeaningFromJson(json);

  Map<String, dynamic> toJson() => _$VocabContextualMeaningToJson(this);
}
