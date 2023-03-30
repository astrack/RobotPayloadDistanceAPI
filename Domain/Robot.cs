using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Domain
{
    public class Robot
    {
        [Key]
        public string robotId { get; set; }
        //public double distanceToGoal { get; set; }
        public int batteryLevel { get; set; }

        public double? distanceToGoal {get; set;}
        public int x { get; set; }
        public int y { get; set; }

        private Payload _payload = new Payload();

        public async Task<Robot> GetClosestRobotIdToPayload(Payload payload)
        {
            _payload = payload;
            var content = await GetjsonStream();
            List<Robot> packageInfo = JsonSerializer.Deserialize<List<Robot>>(content);
            return calcClosestRobot(packageInfo);
        }

        private async Task<string> GetjsonStream(){
            HttpClient client = new HttpClient();
            string url = "https://60c8ed887dafc90017ffbd56.mockapi.io/robots";
            HttpResponseMessage response = await client.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }

        private Robot calcClosestRobot(List<Robot> robotList){
            //order list of robots from lowest
            //then order any matching distances by descending battery
            //[AS]:QUESTION: how should I handle robots > 10 distance? shouldn't their secondary sort be battery as well? 
            Robot robot = robotList.OrderBy(r => calcDistance(r.x, _payload.x, r.y, _payload.y))
    .ThenByDescending(r => r.batteryLevel)
    .FirstOrDefault();
            robot.distanceToGoal = calcDistance(robot.x, _payload.x, robot.y, _payload.y);
            return robot;
            
        }

        private double calcDistance(int x1, int x2, int y1, int y2){
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }
    }
}