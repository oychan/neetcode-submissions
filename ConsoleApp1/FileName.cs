using System;
using System.IO;

namespace DummyFileGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // [경로 설정] 원하는 로컬 작업 드라이브 경로로 수정 가능
            string baseDir = @"C:\BenchmarkTest";
            string largeFileDir = Path.Combine(baseDir, "LargeFile");
            string smallFilesDir = Path.Combine(baseDir, "SmallFiles");

            Directory.CreateDirectory(largeFileDir);
            Directory.CreateDirectory(smallFilesDir);

            // 1. ZFS 압축 왜곡 방지용 4MB 난수 버퍼 생성
            Console.WriteLine("[1/3] 4MB 난수 패턴 버퍼 생성 중...");
            const int bufferSize = 4 * 1024 * 1024; // 4MB
            byte[] randomBuffer = new byte[bufferSize];
            Random.Shared.NextBytes(randomBuffer);

            // 2. 대용량 단일 파일 생성 (15GB)
            string largeFilePath = Path.Combine(largeFileDir, "dummy_15GB.dat");
            long targetLargeSize = 15L * 1024 * 1024 * 1024; // 15 GB
            long writtenLargeBytes = 0;

            Console.WriteLine($"\n[2/3] 대용량 파일 생성 시작 (15GB): {largeFilePath}");
            var sw = System.Diagnostics.Stopwatch.StartNew();

            using (var fs = new FileStream(largeFilePath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize))
            {
                while (writtenLargeBytes < targetLargeSize)
                {
                    int toWrite = (int)Math.Min(bufferSize, targetLargeSize - writtenLargeBytes);
                    fs.Write(randomBuffer, 0, toWrite);
                    writtenLargeBytes += toWrite;

                    if (writtenLargeBytes % (1024L * 1024 * 1024) == 0) // 1GB 단위 진행률 출력
                    {
                        Console.Write($"\r진행률: {writtenLargeBytes / (1024 * 1024 * 1024)}GB / 15GB ({(double)writtenLargeBytes / targetLargeSize * 100:F0}%)");
                    }
                }
            }
            sw.Stop();
            Console.WriteLine($"\n대용량 파일 생성 완료! (소요 시간: {sw.Elapsed.TotalSeconds:F2}초)");

            // 3. 자잘한 파일 생성 (1MB x 1,500개 = 약 1.5GB)
            const int smallFileCount = 1500;
            const int smallFileSize = 1 * 1024 * 1024; // 1MB

            Console.WriteLine($"\n[3/3] 자잘한 파일 생성 시작 (1MB x {smallFileCount}개): {smallFilesDir}");
            sw.Restart();

            for (int i = 1; i <= smallFileCount; i++)
            {
                string smallFilePath = Path.Combine(smallFilesDir, $"file_{i:D4}.dat");
                using (var fs = new FileStream(smallFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    // 난수 버퍼의 앞부분 1MB 기록
                    fs.Write(randomBuffer, 0, smallFileSize);
                }

                if (i % 100 == 0 || i == smallFileCount)
                {
                    Console.Write($"\r진행률: {i} / {smallFileCount}개 ({(double)i / smallFileCount * 100:F0}%)");
                }
            }
            sw.Stop();
            Console.WriteLine($"\n자잘한 파일 생성 완료! (소요 시간: {sw.Elapsed.TotalSeconds:F2}초)");

            Console.WriteLine($"\n모든 더미 파일이 준비되었습니다. 경로: {baseDir}");
        }
    }
}