using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFillingSolution
{
    public class CarFilingSolution
    {
        public int solution(int[] A, int X, int Y, int Z)
        {
            Queue<int> queueCar = new Queue<int>(A);
            var stationsCarMapping = new Dictionary<string, int[]>() { { "X", new int[2] { 0, X } }, { "Y", new int[2] { 0, Y } }, { "Z", new int[2] { 0, Z } } };
            int time = 0;
            int currentCar = -1;
            bool lastCarIsOver = false;
            if (queueCar.Count == 0)
                return -1;
            else if (queueCar.Count == 1)
                return (A[0] > X && A[0] > Y && A[0] > Z) ? -1 : 0;
            else
                currentCar = queueCar.Dequeue();

            while (queueCar.Count != 0)
            {
                Dictionary<string, int[]> availableStations = stationsCarMapping.Where(i => i.Value[0] == 0).ToDictionary(i => i.Key, i => i.Value);
                if (availableStations.Count() == 3 && currentCar > availableStations.Max(i => i.Value[1]))
                    return -1;

                Dictionary<string, int[]> hasEnoughFuelStation = availableStations.Where(i => i.Value[1] >= currentCar).ToDictionary(i => i.Key, i => i.Value);
                while (availableStations.Count() > 0 && hasEnoughFuelStation.Count() >= 1 && !lastCarIsOver)
                {
                    string station = hasEnoughFuelStation.First().Key;
                    stationsCarMapping[station][0] = currentCar;
                    stationsCarMapping[station][1] -= currentCar;

                    availableStations = stationsCarMapping.Where(i => i.Value[0] == 0).ToDictionary(i => i.Key, i => i.Value);
                    if (queueCar.Count > 0)
                        currentCar = queueCar.Dequeue();
                    else
                        lastCarIsOver = true;
                    hasEnoughFuelStation = availableStations.Where(i => i.Value[1] >= currentCar).ToDictionary(i => i.Key, i => i.Value);
                }
                if (!lastCarIsOver)
                {
                    int atLeastWaitingTime = 1;
                    if (availableStations.Count() != 3)
                        atLeastWaitingTime = stationsCarMapping.Where(i => i.Value[0] != 0).Min(i => i.Value[0]);
                    time += atLeastWaitingTime;

                    var stations = stationsCarMapping.Where(i => i.Value[0] != 0).Select(i => i.Key);
                    foreach (var station in stations)
                    {
                        stationsCarMapping[station][0] -= atLeastWaitingTime;
                    }

                    if (queueCar.Count == 0)
                    {
                        if (stationsCarMapping.Select(i => i.Value[1]).Max() < currentCar)
                            return -1;
                        else
                            time += stationsCarMapping.Where(i => i.Value[1] >= currentCar).First().Value[0];
                    }
                }
            }
            return time;
        }
    }
}
