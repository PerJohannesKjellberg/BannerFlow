using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace BannerFlow.Helpers
{
    public sealed class StringOrInt32Serializer : SerializerBase<object> //BsonBaseSerializer
    {
        public override object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            if (context.Reader.CurrentBsonType == BsonType.Int32)
            {
                return context.Reader.ReadInt32();
            }
            if (context.Reader.CurrentBsonType == BsonType.String)
            {
                var value = context.Reader.ReadString();
                if (string.IsNullOrWhiteSpace(value))
                {
                    return null;
                }
                return Convert.ToInt32(value);
            }
            context.Reader.SkipValue();
            return null;
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            if (value == null)
            {
                context.Writer.WriteNull();
                return;
            }
            context.Writer.WriteInt32(Convert.ToInt32(value));
        }
    }
}