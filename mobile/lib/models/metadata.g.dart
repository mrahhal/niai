// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'metadata.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Metadata _$MetadataFromJson(Map<String, dynamic> json) {
  return Metadata()
    ..kanjiCount = json['kanjiCount'] as int
    ..vocabCount = json['vocabCount'] as int
    ..homonymCount = json['homonymCount'] as int
    ..synonymCount = json['synonymCount'] as int
    ..kanjiTagCount = json['kanjiTagCount'] as int
    ..vocabTagCount = json['vocabTagCount'] as int
    ..version = json['version'] as String;
}

Map<String, dynamic> _$MetadataToJson(Metadata instance) => <String, dynamic>{
      'kanjiCount': instance.kanjiCount,
      'vocabCount': instance.vocabCount,
      'homonymCount': instance.homonymCount,
      'synonymCount': instance.synonymCount,
      'kanjiTagCount': instance.kanjiTagCount,
      'vocabTagCount': instance.vocabTagCount,
      'version': instance.version
    };
