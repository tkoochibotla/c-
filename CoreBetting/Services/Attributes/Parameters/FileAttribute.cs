namespace CoreBetting.Services.Attributes.Parameters
{
    public class FileAttribute : ValueAttribute
    {
        public FileAttribute()
        {
            Value = null;
        }

        public FileAttribute(string value)
        {
            Value = value;
        }
    }
}
