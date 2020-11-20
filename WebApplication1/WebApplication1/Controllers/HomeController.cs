using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using WebApplication1.Model;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Web.Services.Description;
using System.IO;
using System.Text.RegularExpressions;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //https://localhost:44328/Home/WindIntensity/?latitude=50&longitude=60
        //[Route("api/Home/WindIntensity/{latitude:decimal,longitude:decimal}/")]
        public decimal WindIntensity(decimal latitude, decimal longitude)
        {

        

            string apikey = "a4aad1be82f76940d5c8d122e1bd834b";
            string baseURL = "https://history.openweathermap.org/data/2.5";

            using (var httpClient = new HttpClient())
            {
                string abc= $"{baseURL}/aggregated/year?lat={latitude}&lon={longitude}&APPID={apikey}";


                var response2 = httpClient.GetStringAsync(new Uri($"{baseURL}/aggregated/year?lat={latitude}&lon={longitude}&APPID={apikey}")).Result;

                var obj1 = JsonConvert.DeserializeObject<Weather>(response2);
            }

            return 0;
        }

       

        public string Index()
        {
            
            return "Lokesh";

        }

        public string[] WsOperations(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return new string[] { "Please enter a valid URL" };
            try
            {
                
                //http://webservices.oorsprong.org/websamples.countryinfo/CountryInfoService.wso?WSDL
                //http://www.thomas-bayer.com/axis2/services/BLZService?wsdl
                List<WsOperation> wsOperations = new List<WsOperation>();
                XmlTextReader reader = new XmlTextReader(url);
                ServiceDescription wsdl = ServiceDescription.Read(reader);
                string opName = "", inParam = "", outParam = "";
                foreach (PortType pt in wsdl.PortTypes)
                {
                    foreach (Operation op in pt.Operations)
                    {
                        opName = op.Name;
                        foreach (OperationMessage msg in op.Messages)
                        {
                            if (msg is OperationInput)
                            {
                                inParam = inParam+msg.Message.Name; // check for two or more input parameters?
                                OperationInput oi = msg as OperationInput;
                            }
                            else if (msg is OperationOutput)
                                outParam = msg.Message.Name;
                        }

                        wsOperations.Add(new WsOperation(opName, inParam, outParam));
                    }
                }
                if (wsOperations.Count > 0)
                {
                    var outputArray = wsOperations.Select(x => x.operationName + "," + x.inputParameter + "," + x.outputParameter).ToArray();
                    return outputArray;
                }
                else
                {
                    return new string[] { "There are no Operations in the provided URL. Please try with different URL" };
                }
                

            }
            catch(Exception e)
            {
                return new string[] { e.Message };
            }
            finally
            {

            }
        }



        //***********************************************************************************************

        //https://www.ranks.nl/stopwords

        private readonly HashSet<string> _stopWords = new HashSet<string>(StringComparer.CurrentCultureIgnoreCase){ "a",
"about","above","across","id","href","span","class",
"after",
"again",
"against",
"all",
"almost",
"alone",
"along",
"already",
"also",
"although",
"always",
"among",
"an",
"and",
"another",
"any",
"anybody",
"anyone",
"anything",
"anywhere",
"are",
"area",
"areas",
"around",
"as",
"ask",
"asked",
"asking",
"asks",
"at",
"away",
"b",
"back",
"backed",
"backing",
"backs",
"be",
"became",
"because",
"become",
"becomes",
"been",
"before",
"began",
"behind",
"being",
"beings",
"best",
"better",
"between",
"big",
"both",
"but",
"by",
"c",
"came",
"can",
"cannot",
"case",
"cases",
"certain",
"certainly",
"clear",
"clearly",
"come",
"could",
"d",
"did",
"differ",
"different",
"differently",
"do",
"does",
"done",
"down",
"down",
"downed",
"downing",
"downs",
"during",
"e",
"each",
"early",
"either",
"end",
"ended",
"ending",
"ends",
"enough",
"even",
"evenly",
"ever",
"every",
"everybody",
"everyone",
"everything",
"everywhere",
"f",
"face",
"faces",
"fact",
"facts",
"far",
"felt",
"few",
"find",
"finds",
"first",
"for",
"four",
"from",
"full",
"fully",
"further",
"furthered",
"furthering",
"furthers",
"g",
"gave",
"general",
"generally",
"get",
"gets",
"give",
"given",
"gives",
"go",
"going",
"good",
"goods",
"got",
"great",
"greater",
"greatest",
"group",
"grouped",
"grouping",
"groups",
"h",
"had",
"has",
"have",
"having",
"he",
"her",
"here",
"herself",
"high",
"high",
"high",
"higher",
"highest",
"him",
"himself",
"his",
"how",
"however",
"i",
"if",
"important",
"in",
"interest",
"interested",
"interesting",
"interests",
"into",
"is",
"it",
"its",
"itself",
"j",
"just",
"k",
"keep",
"keeps",
"kind",
"knew",
"know",
"known",
"knows",
"l",
"large",
"largely",
"last",
"later",
"latest",
"least",
"less",
"let",
"lets",
"like",
"likely",
"long",
"longer",
"longest",
"m",
"made",
"make",
"making",
"man",
"many",
"may",
"me",
"member",
"members",
"men",
"might",
"more",
"most",
"mostly",
"mr",
"mrs",
"much",
"must",
"my",
"myself",
"n",
"necessary",
"need",
"needed",
"needing",
"needs",
"never",
"new",
"new",
"newer",
"newest",
"next",
"no",
"nobody",
"non",
"noone",
"not",
"nothing",
"now",
"nowhere",
"number",
"numbers",
"o",
"of",
"off",
"often",
"old",
"older",
"oldest",
"on",
"once",
"one",
"only",
"open",
"opened",
"opening",
"opens",
"or",
"order",
"ordered",
"ordering",
"orders",
"other",
"others",
"our",
"out",
"over",
"p",
"part",
"parted",
"parting",
"parts",
"per",
"perhaps",
"place",
"places",
"point",
"pointed",
"pointing",
"points",
"possible",
"present",
"presented",
"presenting",
"presents",
"problem",
"problems",
"put",
"puts",
"q",
"quite",
"r",
"rather",
"really",
"right",
"right",
"room",
"rooms",
"s",
"said",
"same",
"saw",
"say",
"says",
"second",
"seconds",
"see",
"seem",
"seemed",
"seeming",
"seems",
"sees",
"several",
"shall",
"she",
"should",
"show",
"showed",
"showing",
"shows",
"side",
"sides",
"since",
"small",
"smaller",
"smallest",
"so",
"some",
"somebody",
"someone",
"something",
"somewhere",
"state",
"states",
"still",
"still",
"such",
"sure",
"t",
"take",
"taken",
"than",
"that",
"the",
"their",
"them",
"then",
"there",
"therefore",
"these",
"they",
"thing",
"things",
"think",
"thinks",
"this",
"those",
"though",
"thought",
"thoughts",
"three",
"through",
"thus",
"to",
"today",
"together",
"too",
"took",
"toward",
"turn",
"turned",
"turning",
"turns",
"two",
"u",
"under",
"until",
"up",
"upon",
"us",
"use",
"used",
"uses",
"v",
"very",
"w",
"want",
"wanted",
"wanting",
"wants",
"was",
"way",
"ways",
"we",
"well",
"wells",
"went",
"were",
"what",
"when",
"where",
"whether",
"which",
"while",
"who",
"whole",
"whose",
"why",
"will",
"with",
"within",
"without",
"work",
"worked",
"working",
"works",
"would",
"x",
"y",
"year",
"years",
"yet",
"you",
"young",
"younger",
"youngest",
"your",
"yours",
"z","!doctype","doctype","a","abbr","address","area","article","aside","b","base","bdi",
            "bdo","blockquote","body","br","button","canvas","caption","cite","code","col",
            "colgroup","data","datalist","dd","del","details","dfn","dialog","div","dl","dt",
            "em","embed","fieldset","figure","footer","form","h1","h2","h3","h4","h5","h6","head",
            "header","hgroup","hr","html","i","iframe","img","input","ins","kbd","keygen","label",
            "legend","li","link","main","map","mark","menu","menuitem","meta","meter","nav","noscript",
            "object","ol","optgroup","option","output","p","param","pre","progress","q","rb","rp","rt",
            "rtc","ruby","s","samp","script","section","select","small","source","span","strong","style",
            "sub","summary","sup","table","tbody","td","template","textarea",
            "tfoot","th","thead","time","title","tr","track","u","ul","var","video","wbr","", "amp","text","org","title","lang","dir","class","accesskey",
            "hidden","id","spellcheck","style","tabindex","translate","rft","http","https","rel","cite_ref","cite_note","info","mw","com","www"

        };
        public string Top10ContentWords(string url)
        {
            //https://localhost:44328/Home/Top10ContentWords?url=https://en.wikipedia.org/wiki/Sacha_Baron_Cohen
            string data = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (String.IsNullOrWhiteSpace(response.CharacterSet))
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }
            
            

            var contentWords = Regex.Split(data, @"[\W\d]+").Where(c => !String.IsNullOrWhiteSpace(c) && !_stopWords.Contains(c)).Select(c=>c);
            var topTenContentWords = (from w in contentWords
                                      group w by w
                                          into g
                                      let count = g.Count()
                                      orderby count descending
                                      select g.Key).Take(10);
            return topTenContentWords.ToString();

        }
    }
}
