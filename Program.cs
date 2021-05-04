using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace vize1
{
    class Program
    {
        private static object rows;
        private static string exitStatus;
        private static string content;

        public static object Ports { get; private set; }

        static void Main(string[] args)
        {

            using (Process p = new Process())
            {

                ProcessStartInfo ps = new ProcessStartInfo();
                ps.Arguments = "-a -n ";
                ps.FileName = "netstat.exe";
                ps.UseShellExecute = false;
                ps.WindowStyle = ProcessWindowStyle.Hidden;
                ps.RedirectStandardInput = true;
                ps.RedirectStandardOutput = true;
                ps.RedirectStandardError = true;

                p.StartInfo = ps;
                p.Start();

                StreamReader stdOutput = p.StandardOutput;
                StreamReader stdError = p.StandardError;

                string content = stdOutput.ReadToEnd() + stdError.ReadToEnd();
                string exitStatus = p.ExitCode.ToString();

                if (exitStatus != "0")
                {
                    // Command Errored. Handle Here If Need Be
                }

                //Get The Rows
                string[] rows = Regex.Split(content, "\r\n");
                foreach (string row in rows)
                {
                    //Split it baby
                    string[] tokens = Regex.Split(row, "\\s+");
                    if (tokens.Length > 4 &&  tokens[1].Equals("TCP"))
                    {
                        string localAddress = Regex.Replace(tokens[2], @"\[(.*?)\]", "1.1.1.1");
                        Ports.Add(new Port
                        {
                            protocol = localAddress.Contains("1.1.1.1") ? String.Format("{0}v6", tokens[1]) : String.Format("{0}v4", tokens[1]),
                            port_number = localAddress.Split(':')[1],
                           });
                    }
                }
            }

            if (exitStatus != "0")
                {
                    // Command Errored. Handle Here If Need Be
                }

                //Get The Rows
                string[] rows = Regex.Split(content, "\r\n");

                foreach (var item in rows)
                {
                    if (item == "") continue;
                    
                    if (item.Trim() == "Active Connections")continue; 
                    if (item.Contains("TCP"))
                    {
                        var dizi = item.Split(' ');
                    }
                    
                }

                }

        private static object LookupProcess(short v)
        {
            throw new NotImplementedException();
        }



        {
    {
    [Route("api/[controller]")]
        [ApiController]
        public class OrnekJsonController : ControllerBase
        {
            public object JsonConvert { get; private set; }

            // GET api/values
            [HttpGet]
            public ActionResult<string> Get()
            {
                List<Member> liste = new List<Member>
            {
                new Member { Port= " port:443", ForeginAddress= " foreginAddress:55.143.25.2" },
                new Member { port = "port:482", ForeginAddress = "foreginAddress:55.143.25.1" },
                new Member { Port = "port:1002", ForeginAddress = " foreginAddress:55.143.25.4" }
            };
                string json = JsonConvert.SerializeObject(liste);
                return json;
            }
        }




    }
    }




