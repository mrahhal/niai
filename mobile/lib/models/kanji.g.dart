// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'kanji.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

KanjiSummary _$KanjiSummaryFromJson(Map<String, dynamic> json) {
  return KanjiSummary()
    ..character = json['character'] as String
    ..meanings = (json['meanings'] as List)?.map((e) => e as String)?.toList()
    ..onyomi = json['onyomi'] as String
    ..kunyomi = json['kunyomi'] as String
    ..waniKaniLevel = json['waniKaniLevel'] as int
    ..tags = (json['tags'] as List)
        ?.map((e) => e == null ? null : Tag.fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..frequency = json['frequency'] as int
    ..strokes = json['strokes'] as int
    ..jlpt = json['jlpt'] as int
    ..grade = json['grade'] as int;
}

Map<String, dynamic> _$KanjiSummaryToJson(KanjiSummary instance) =>
    <String, dynamic>{
      'character': instance.character,
      'meanings': instance.meanings,
      'onyomi': instance.onyomi,
      'kunyomi': instance.kunyomi,
      'waniKaniLevel': instance.waniKaniLevel,
      'tags': instance.tags,
      'frequency': instance.frequency,
      'strokes': instance.strokes,
      'jlpt': instance.jlpt,
      'grade': instance.grade
    };

KanjiSimilar _$KanjiSimilarFromJson(Map<String, dynamic> json) {
  return KanjiSimilar()
    ..character = json['character'] as String
    ..meanings = (json['meanings'] as List)?.map((e) => e as String)?.toList()
    ..onyomi = json['onyomi'] as String
    ..kunyomi = json['kunyomi'] as String
    ..waniKaniLevel = json['waniKaniLevel'] as int
    ..tags = (json['tags'] as List)
        ?.map((e) => e == null ? null : Tag.fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..frequency = json['frequency'] as int
    ..strokes = json['strokes'] as int
    ..jlpt = json['jlpt'] as int
    ..grade = json['grade'] as int
    ..score = (json['score'] as num)?.toDouble();
}

Map<String, dynamic> _$KanjiSimilarToJson(KanjiSimilar instance) =>
    <String, dynamic>{
      'character': instance.character,
      'meanings': instance.meanings,
      'onyomi': instance.onyomi,
      'kunyomi': instance.kunyomi,
      'waniKaniLevel': instance.waniKaniLevel,
      'tags': instance.tags,
      'frequency': instance.frequency,
      'strokes': instance.strokes,
      'jlpt': instance.jlpt,
      'grade': instance.grade,
      'score': instance.score
    };

Kanji _$KanjiFromJson(Map<String, dynamic> json) {
  return Kanji()
    ..character = json['character'] as String
    ..meanings = (json['meanings'] as List)?.map((e) => e as String)?.toList()
    ..onyomi = json['onyomi'] as String
    ..kunyomi = json['kunyomi'] as String
    ..waniKaniLevel = json['waniKaniLevel'] as int
    ..tags = (json['tags'] as List)
        ?.map((e) => e == null ? null : Tag.fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..frequency = json['frequency'] as int
    ..strokes = json['strokes'] as int
    ..jlpt = json['jlpt'] as int
    ..grade = json['grade'] as int
    ..similar = (json['similar'] as List)
        ?.map((e) =>
            e == null ? null : KanjiSimilar.fromJson(e as Map<String, dynamic>))
        ?.toList();
}

Map<String, dynamic> _$KanjiToJson(Kanji instance) => <String, dynamic>{
      'character': instance.character,
      'meanings': instance.meanings,
      'onyomi': instance.onyomi,
      'kunyomi': instance.kunyomi,
      'waniKaniLevel': instance.waniKaniLevel,
      'tags': instance.tags,
      'frequency': instance.frequency,
      'strokes': instance.strokes,
      'jlpt': instance.jlpt,
      'grade': instance.grade,
      'similar': instance.similar
    };
