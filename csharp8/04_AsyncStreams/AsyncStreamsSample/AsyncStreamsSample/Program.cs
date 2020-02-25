using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncStreamsSample
{
    class Program
    {
        static async Task Main()
        {
            await Demo1Async();
            // await Demo2Async();
            // await Demo3Async();
        }

        private static async Task Demo1Async()
        {
            var aDevice = new ADevice();

            await foreach (var x in aDevice.GetSensorData1())
            {
                Console.WriteLine($"{x.Value1} {x.Value2}");
            }
        }

        private static async Task Demo2Async()
        {
            var aDevice = new ADevice();

            IAsyncEnumerable<SensorData> en = aDevice.GetSensorData1();
            IAsyncEnumerator<SensorData> enumerator = en.GetAsyncEnumerator();
            try
            {
                while (await enumerator.MoveNextAsync())
                {
                    var sensorData = enumerator.Current;
                    Console.WriteLine($"{sensorData.Value1} {sensorData.Value2}");
                }
            }
            finally
            {
                await enumerator.DisposeAsync();
            }
        }

        private static async Task Demo3Async()
        {
            try
            {
                var cts = new CancellationTokenSource();
                cts.CancelAfter(5000);
                var aDevice = new ADevice();

                await foreach (var x in aDevice.GetSensorData2().WithCancellation(cts.Token))
                {
                    Console.WriteLine($"{x.Value1} {x.Value2}");
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
