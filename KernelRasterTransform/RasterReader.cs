namespace KernelRasterTransform
{
    public static class RasterReader
    {
        public static Raster ReadRaster(string path)
        {
            using FileStream file = new(path, FileMode.Open, FileAccess.Read, FileShare.None,
                bufferSize: 4096, FileOptions.SequentialScan);
            using StreamReader reader = new(file);
            FileInfo info = new(path);
            long maxValues = info.Length / 2;
            string? line = reader.ReadLine();
            if (line is null) return new Raster(Data: Array.Empty<double>(), Width: 0, Height: 0);
            var data = new double[maxValues];
            int width = DeserializeLine(line, data, offset: 0);
            int height = 1;
            int offset = width;
            while ((line = reader.ReadLine()) is not null)
            {
                int widthRow = DeserializeLine(line, data, offset);
                if (widthRow != width) throw new ArgumentException("not rectangular raster", nameof(path));
                offset += width;
                height++;
            }
            Array.Resize(ref data, offset);
            return new Raster(data, width, height);
            int DeserializeLine(string line, double[] data, int offset)
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
                    data[index] = double.TryParse(substring, out double d) ? d : double.NaN;
                    start = end + 1;
                    count++;
                }
            }
        }
    }
}