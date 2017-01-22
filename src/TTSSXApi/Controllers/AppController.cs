using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TTSSXApi.Models.Request;
using TTSSXApi.Models.Db;
using TTSSXApi.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace TTSSXApi.Controllers
{
    [Route("api/app")]
    public class AppController : Controller
    {
        private readonly TtssxContext cx;

        public AppController(TtssxContext _context)
        {
            cx = _context;
        }

        // POST api/app
        [HttpPost]
        public PassagePostRs Post([FromBody]PassagePost value)
        {
            cx.Passages.Add(new Passage
            {
                CompositionNo = value.CompositionNo,
                Line = value.Line,
                PlannedTime = value.PlannedTime,
                submitTime = DateTime.Now,
                TheirId = value.TheirId,
                TramNo = value.TramNo,
                VehicleId = value.VehicleId,
                RouteId = value.RouteId,
                TripId = value.TripId,
                Direction = value.Direction
            });

            cx.SaveChanges();

            int vehicleIds = cx.Passages.Where(p => p.VehicleId == value.VehicleId).Count();
            int passageIds = cx.Passages.Where(p => p.TheirId == value.TheirId).Count();

            return new PassagePostRs
            {
                VehicleInstances = vehicleIds,
                PassageInstances = passageIds
            };
        }

        [HttpPost]
        [Route("trams")]
        public TramGetRs GetTrams([FromBody]TramGet tramids)
        {
            try
            {
                TramGetRs result = new TramGetRs();
                List<TramGetItem> items = new List<Models.Response.TramGetItem>();
                foreach (string id in tramids.Trams)
                {
                    Tram tr = cx.Trams.Include(t => t.TramType).FirstOrDefault(t => t.TheirId == id.Trim());
                    if (tr != null)
                    {
                        items.Add(new TramGetItem
                        {
                            TramId = id,
                            TramNo = tr.SideNo,
                            Name = tr.TramType.Name,
                            LowFloor = tr.TramType.LowFloor,
                            ExtraInfo = tr.ExtraInfo
                        });
                    }
                }

                result.Items = items.ToArray();

                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet]
        [Route("trams/{id}")]
        public TramGetItem GetTram([FromRoute]string id)
        {
            try
            {
                Tram tr = cx.Trams.Include(t => t.TramType).FirstOrDefault(t => t.TheirId == id.Trim());
                if (tr != null)
                {
                    return new TramGetItem
                    {
                        TramId = id,
                        TramNo = tr.SideNo,
                        Name = tr.TramType.Name,
                        LowFloor = tr.TramType.LowFloor
                    };
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet]
        [Route("status")]
        public string GetStatus()
        {
            return $"App: OK <br />\r\nDB: {(cx.Trams.Any() ? "OK" : "ERR")} <br />\r\nTrams: {cx.Trams.Count()}";
        }
    }
}
