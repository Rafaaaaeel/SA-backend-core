namespace Sa.Core.Helpers;

public static class CompactString
{

    public static string? Decompress(string input)
    {
        try
        {
            byte[] compressed = Convert.FromBase64String(input);
            byte[] decompressed = Decompress(compressed);

            return Encoding.UTF8.GetString(decompressed);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public static byte[] Decompress(byte[] input)
    {
        MemoryStream source = new(input);
        byte[] result;

        using (GZipStream decopressionStream = new(source, CompressionMode.Decompress))
        {
            MemoryStream decompressed = new();
            decopressionStream.CopyTo(decompressed);
            result = decompressed.ToArray();
        }

        return result;
    }

    public static string Compress(string input)
    {
        byte[] encoded = Encoding.UTF8.GetBytes(input);
        byte[] compressed = Compress(encoded);
        return Convert.ToBase64String(compressed);
    }

    public static byte[] Compress(byte[] input)
    {
        MemoryStream result = new();

        using (MemoryStream uncompressed = new(input))
        {
            using GZipStream compressionStream = new(result, CompressionLevel.Fastest, true);
            uncompressed.CopyTo(compressionStream);
        }
        
        return result.ToArray();
    }
}