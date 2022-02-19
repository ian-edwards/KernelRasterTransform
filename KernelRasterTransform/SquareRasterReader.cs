namespace KernelRasterTransform
{
    public static class SquareRasterReader
    {
        public static SquareRaster ReadSquareRaster(string path)
        {
            using FileStream file = new(path, FileMode.Open, FileAccess.Read, FileShare.None,
                bufferSize: 4096, FileOptions.SequentialScan);
            using StreamReader reader = new(file);
            string? line = reader.ReadLine();
            if (line is null) return new SquareRaster(0);
            var data = new float[line.Length];
            int edgeSize = Deserialize(line, data, 0);
            int size = edgeSize * edgeSize;
            Array.Resize(ref data, size);
            int offset = edgeSize;
            while ((line = reader.ReadLine()) is not null)
            {
                int rowSize = Deserialize(line, data, offset);
                if (rowSize != edgeSize) throw new ArgumentException("not square raster", nameof(path));
                offset += rowSize;
            }
            int rowCount = offset / edgeSize;
            if (rowCount != edgeSize) throw new ArgumentException("not square raster", nameof(path));
            return new SquareRaster(edgeSize, data);
        }

        static int Deserialize(string line, float[] data, int offset)
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
                int index = offset + count;
                if (float.TryParse(substring, out float value))
                {
                    data[index] = value;
                }
                else
                {
                    data[index] = float.NaN;
                }
                start = end + 1;
                count++;
            }
        }
    }
}