import 'package:json_annotation/json_annotation.dart';

part 'metadata.g.dart';

@JsonSerializable()
class Metadata {
  Metadata();

  int kanjiCount;
  int vocabCount;
  int homonymCount;
  int synonymCount;
  int kanjiTagCount;
  int vocabTagCount;
  String version;

  factory Metadata.fromJson(Map<String, dynamic> json) =>
      _$MetadataFromJson(json);

  Map<String, dynamic> toJson() => _$MetadataToJson(this);
}
