using Microsoft.AspNetCore.Mvc;

namespace AdahiBackend.Controllers
{
    [ApiController]
    [Route("api/logistics")]
    public class LogisticsController : ControllerBase
    {
        private static int _nextDistributionId = 1;
        private static int _nextShipmentStatusId = 1;
        private static int _nextInternationalShippingId = 1;
        private static int _nextKsaShippingId = 1;
        private static int _nextMakkahGovernorateId = 1;
        private static int _nextScopeStatsId = 1;

        private static readonly List<DistributionEntry> DistributionEntries = new();
        private static readonly List<ShipmentStatusEntry> ShipmentStatusEntries = new();
        private static readonly List<InternationalShippingEntry> InternationalShippingEntries = new();
        private static readonly List<KsaShippingEntry> KsaShippingEntries = new();
        private static readonly List<MakkahGovernorateEntry> MakkahGovernorateEntries = new();
        private static readonly List<ScopeStatsEntry> ScopeStatsEntries = new();

        [HttpGet("distribution")]
        public ActionResult<IEnumerable<DistributionEntry>> GetDistribution([FromQuery] string? scope)
        {
            var entries = string.IsNullOrWhiteSpace(scope)
                ? DistributionEntries
                : DistributionEntries.Where(item => item.Scope == scope).ToList();
            return Ok(entries);
        }

        [HttpPost("distribution")]
        public ActionResult CreateDistribution([FromBody] DistributionEntryRequest request)
        {
            var entry = new DistributionEntry
            {
                Id = _nextDistributionId++,
                Scope = request.Scope,
                Name = request.Name,
                Value = request.Value,
                Fill = request.Fill
            };

            DistributionEntries.Add(entry);
            return Ok(new { id = entry.Id });
        }

        [HttpPut("distribution/{id:int}")]
        public ActionResult UpdateDistribution(int id, [FromBody] DistributionEntryRequest request)
        {
            var entry = DistributionEntries.FirstOrDefault(item => item.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            entry.Scope = request.Scope;
            entry.Name = request.Name;
            entry.Value = request.Value;
            entry.Fill = request.Fill;
            return Ok(new { id = entry.Id });
        }

        [HttpDelete("distribution/{id:int}")]
        public ActionResult DeleteDistribution(int id)
        {
            var entry = DistributionEntries.FirstOrDefault(item => item.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            DistributionEntries.Remove(entry);
            return Ok(new { deleted = true });
        }

        [HttpGet("shipment-status")]
        public ActionResult<IEnumerable<ShipmentStatusEntry>> GetShipmentStatus()
        {
            return Ok(ShipmentStatusEntries);
        }

        [HttpPost("shipment-status")]
        public ActionResult CreateShipmentStatus([FromBody] ShipmentStatusRequest request)
        {
            var entry = new ShipmentStatusEntry
            {
                Id = _nextShipmentStatusId++,
                Status = request.Status,
                Count = request.Count
            };

            ShipmentStatusEntries.Add(entry);
            return Ok(new { id = entry.Id });
        }

        [HttpPut("shipment-status/{id:int}")]
        public ActionResult UpdateShipmentStatus(int id, [FromBody] ShipmentStatusRequest request)
        {
            var entry = ShipmentStatusEntries.FirstOrDefault(item => item.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            entry.Status = request.Status;
            entry.Count = request.Count;
            return Ok(new { id = entry.Id });
        }

        [HttpDelete("shipment-status/{id:int}")]
        public ActionResult DeleteShipmentStatus(int id)
        {
            var entry = ShipmentStatusEntries.FirstOrDefault(item => item.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            ShipmentStatusEntries.Remove(entry);
            return Ok(new { deleted = true });
        }

        [HttpGet("international-shipping")]
        public ActionResult<IEnumerable<InternationalShippingEntry>> GetInternationalShipping()
        {
            return Ok(InternationalShippingEntries);
        }

        [HttpPost("international-shipping")]
        public ActionResult CreateInternationalShipping([FromBody] InternationalShippingRequest request)
        {
            var entry = new InternationalShippingEntry
            {
                Id = _nextInternationalShippingId++,
                Country = request.Country,
                Carcasses = request.Carcasses,
                Boxes = request.Boxes,
                Port = request.Port,
                Containers = request.Containers,
                Status = request.Status,
                Coords = request.Coords,
                Flag = request.Flag
            };

            InternationalShippingEntries.Add(entry);
            return Ok(new { id = entry.Id });
        }

        [HttpPut("international-shipping/{id:int}")]
        public ActionResult UpdateInternationalShipping(int id, [FromBody] InternationalShippingRequest request)
        {
            var entry = InternationalShippingEntries.FirstOrDefault(item => item.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            entry.Country = request.Country;
            entry.Carcasses = request.Carcasses;
            entry.Boxes = request.Boxes;
            entry.Port = request.Port;
            entry.Containers = request.Containers;
            entry.Status = request.Status;
            entry.Coords = request.Coords;
            entry.Flag = request.Flag;
            return Ok(new { id = entry.Id });
        }

        [HttpDelete("international-shipping/{id:int}")]
        public ActionResult DeleteInternationalShipping(int id)
        {
            var entry = InternationalShippingEntries.FirstOrDefault(item => item.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            InternationalShippingEntries.Remove(entry);
            return Ok(new { deleted = true });
        }

        [HttpGet("ksa-shipping")]
        public ActionResult<IEnumerable<KsaShippingEntry>> GetKsaShipping()
        {
            return Ok(KsaShippingEntries);
        }

        [HttpPost("ksa-shipping")]
        public ActionResult CreateKsaShipping([FromBody] KsaShippingRequest request)
        {
            var entry = new KsaShippingEntry
            {
                Id = _nextKsaShippingId++,
                Region = request.Region,
                Carcasses = request.Carcasses,
                Boxes = request.Boxes,
                Recipient = request.Recipient,
                Status = request.Status,
                Flag = request.Flag
            };

            KsaShippingEntries.Add(entry);
            return Ok(new { id = entry.Id });
        }

        [HttpPut("ksa-shipping/{id:int}")]
        public ActionResult UpdateKsaShipping(int id, [FromBody] KsaShippingRequest request)
        {
            var entry = KsaShippingEntries.FirstOrDefault(item => item.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            entry.Region = request.Region;
            entry.Carcasses = request.Carcasses;
            entry.Boxes = request.Boxes;
            entry.Recipient = request.Recipient;
            entry.Status = request.Status;
            entry.Flag = request.Flag;
            return Ok(new { id = entry.Id });
        }

        [HttpDelete("ksa-shipping/{id:int}")]
        public ActionResult DeleteKsaShipping(int id)
        {
            var entry = KsaShippingEntries.FirstOrDefault(item => item.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            KsaShippingEntries.Remove(entry);
            return Ok(new { deleted = true });
        }

        [HttpGet("makkah-governorates")]
        public ActionResult<IEnumerable<MakkahGovernorateEntry>> GetMakkahGovernorates()
        {
            return Ok(MakkahGovernorateEntries);
        }

        [HttpPost("makkah-governorates")]
        public ActionResult CreateMakkahGovernorate([FromBody] MakkahGovernorateRequest request)
        {
            var entry = new MakkahGovernorateEntry
            {
                Id = _nextMakkahGovernorateId++,
                Region = request.Region,
                Carcasses = request.Carcasses,
                Boxes = request.Boxes,
                Recipient = request.Recipient,
                Status = request.Status,
                Flag = request.Flag,
                Coords = request.Coords
            };

            MakkahGovernorateEntries.Add(entry);
            return Ok(new { id = entry.Id });
        }

        [HttpPut("makkah-governorates/{id:int}")]
        public ActionResult UpdateMakkahGovernorate(int id, [FromBody] MakkahGovernorateRequest request)
        {
            var entry = MakkahGovernorateEntries.FirstOrDefault(item => item.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            entry.Region = request.Region;
            entry.Carcasses = request.Carcasses;
            entry.Boxes = request.Boxes;
            entry.Recipient = request.Recipient;
            entry.Status = request.Status;
            entry.Flag = request.Flag;
            entry.Coords = request.Coords;
            return Ok(new { id = entry.Id });
        }

        [HttpDelete("makkah-governorates/{id:int}")]
        public ActionResult DeleteMakkahGovernorate(int id)
        {
            var entry = MakkahGovernorateEntries.FirstOrDefault(item => item.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            MakkahGovernorateEntries.Remove(entry);
            return Ok(new { deleted = true });
        }

        [HttpGet("scope-stats")]
        public ActionResult GetScopeStats([FromQuery] string? scope)
        {
            if (string.IsNullOrWhiteSpace(scope))
            {
                return Ok(ScopeStatsEntries);
            }

            var entry = ScopeStatsEntries.FirstOrDefault(item => item.Scope == scope);
            if (entry == null)
            {
                return NotFound();
            }

            return Ok(entry);
        }

        [HttpPost("scope-stats")]
        public ActionResult CreateScopeStats([FromBody] ScopeStatsRequest request)
        {
            var entry = new ScopeStatsEntry
            {
                Id = _nextScopeStatsId++,
                Scope = request.Scope,
                Countries = request.Countries,
                Associations = request.Associations,
                Beneficiaries = request.Beneficiaries,
                Carcasses = request.Carcasses,
                Boxes = request.Boxes,
                CarcassesChange = request.CarcassesChange,
                BoxesChange = request.BoxesChange,
                TypeLabel = request.TypeLabel
            };

            ScopeStatsEntries.Add(entry);
            return Ok(new { id = entry.Id });
        }

        [HttpPut("scope-stats/{id:int}")]
        public ActionResult UpdateScopeStats(int id, [FromBody] ScopeStatsRequest request)
        {
            var entry = ScopeStatsEntries.FirstOrDefault(item => item.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            entry.Scope = request.Scope;
            entry.Countries = request.Countries;
            entry.Associations = request.Associations;
            entry.Beneficiaries = request.Beneficiaries;
            entry.Carcasses = request.Carcasses;
            entry.Boxes = request.Boxes;
            entry.CarcassesChange = request.CarcassesChange;
            entry.BoxesChange = request.BoxesChange;
            entry.TypeLabel = request.TypeLabel;
            return Ok(new { id = entry.Id });
        }

        [HttpDelete("scope-stats/{id:int}")]
        public ActionResult DeleteScopeStats(int id)
        {
            var entry = ScopeStatsEntries.FirstOrDefault(item => item.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            ScopeStatsEntries.Remove(entry);
            return Ok(new { deleted = true });
        }
    }

    public class DistributionEntryRequest
    {
        public string Scope { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Value { get; set; }
        public string Fill { get; set; } = string.Empty;
    }

    public class DistributionEntry : DistributionEntryRequest
    {
        public int Id { get; set; }
    }

    public class ShipmentStatusRequest
    {
        public string Status { get; set; } = string.Empty;
        public int Count { get; set; }
    }

    public class ShipmentStatusEntry : ShipmentStatusRequest
    {
        public int Id { get; set; }
    }

    public class InternationalShippingRequest
    {
        public string Country { get; set; } = string.Empty;
        public int Carcasses { get; set; }
        public int Boxes { get; set; }
        public string Port { get; set; } = string.Empty;
        public int Containers { get; set; }
        public string Status { get; set; } = string.Empty;
        public MapCoords Coords { get; set; } = new();
        public string Flag { get; set; } = string.Empty;
    }

    public class InternationalShippingEntry : InternationalShippingRequest
    {
        public int Id { get; set; }
    }

    public class KsaShippingRequest
    {
        public string Region { get; set; } = string.Empty;
        public int Carcasses { get; set; }
        public int Boxes { get; set; }
        public string Recipient { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Flag { get; set; } = string.Empty;
    }

    public class KsaShippingEntry : KsaShippingRequest
    {
        public int Id { get; set; }
    }

    public class MakkahGovernorateRequest
    {
        public string Region { get; set; } = string.Empty;
        public int Carcasses { get; set; }
        public int Boxes { get; set; }
        public string Recipient { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Flag { get; set; } = string.Empty;
        public MapCoords Coords { get; set; } = new();
    }

    public class MakkahGovernorateEntry : MakkahGovernorateRequest
    {
        public int Id { get; set; }
    }

    public class ScopeStatsRequest
    {
        public string Scope { get; set; } = string.Empty;
        public string Countries { get; set; } = string.Empty;
        public string Associations { get; set; } = string.Empty;
        public string? Beneficiaries { get; set; }
        public string Carcasses { get; set; } = string.Empty;
        public string Boxes { get; set; } = string.Empty;
        public string CarcassesChange { get; set; } = string.Empty;
        public string BoxesChange { get; set; } = string.Empty;
        public string TypeLabel { get; set; } = string.Empty;
    }

    public class ScopeStatsEntry : ScopeStatsRequest
    {
        public int Id { get; set; }
    }

    public class MapCoords
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
