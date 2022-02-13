namespace KernelRasterTransform
{
    public static class RasterReader
    {
        public static Raster ReadRaster(string path)
        {
            using FileStream file = new(path, FileMode.Open, FileAccess.Read, FileShare.None,
                bufferSize: 4096, FileOptions.SequentialScan);
            using StreamReader reader = new(file);
            string? line = reader.ReadLine();
            if (line is null) return new Raster(0);
            float?[] data = new float?[line.Length];
            int edgeSize = Deserialize(line, data, 0);
            int size = edgeSize * edgeSize;
            Array.Resize(ref data, size);
            int offset = edgeSize;
            while ((line = reader.ReadLine()) is not null)
            {
                Deserialize(line, data, offset);
                // todo validate width
                offset += edgeSize;
            }
            // todo validate height
            return new Raster(edgeSize, data);
        }

        static int Deserialize(string line, float?[] data, int offset)
        {
            int start = 0;
            int count = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ',')
                {
                    DeserializeValue(i);
                }
            }
            DeserializeValue(line.Length);
            return count;
            void DeserializeValue(int end)
            {
                int length = end - start;
                string substring = line.Substring(start, length);
                if (float.TryParse(substring, out float value))
                {
                    data[offset + count] = value;
                }
                start = end + 1;
                count++;
            }
        }
    }
}