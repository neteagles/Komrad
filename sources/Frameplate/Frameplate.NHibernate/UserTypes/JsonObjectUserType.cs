namespace Frameplate.NHibernate.UserTypes
{
    using System;
    using System.Data;
    using global::NHibernate.SqlTypes;
    using global::NHibernate.UserTypes;

    public class JsonObjectUserType<T> : JsonObject<T>, IUserType
        where T : class
    {
        public SqlType[] SqlTypes
        {
            get { return new[] {new SqlType(DbType.Object)}; }
        }

        public bool Equals(object x, object y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return x.Equals(y);
        }

        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }

        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            var json = rs[names[0]]?.ToString();
            if (json == null)
                return null;

            var value = JsonConvert.DeserializeObject<T>(json);

            return new JsonObject<T>(value, json);
        }

        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            var jsonObject = value as JsonObject<T>;
            var jsonString = JsonConvert.SerializeObject(jsonObject?.Value, Formatting.None);

            var dbDataParameter = (IDbDataParameter) cmd.Parameters[index];
            dbDataParameter.Value = jsonString.Replace("'", "''");
        }

        public object DeepCopy(object value)
        {
            return value;
        }

        public object Replace(object original, object target, object owner)
        {
            return original;
        }

        public object Assemble(object cached, object owner)
        {
            return cached;
        }

        public object Disassemble(object value)
        {
            return value;
        }

        public Type ReturnedType
        {
            get { return typeof (string); }
        }

        public bool IsMutable
        {
            get { return false; }
        }
    }
}