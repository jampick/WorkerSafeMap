using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;

namespace populateDB.model
{
    class IncidentEntity : TableEntity
    {
        public IncidentEntity(string partitionName, string rowName)
        {
            PartitionKey = partitionName;
            RowKey = rowName;
        }

        public string ID { get; set; }
        public string UPA { get; set; }
        public DateTime EventDate { get; set; }
        public string Employer { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string PrimaryNAICS { get; set; }
        public string Hospitalized { get; set; }
        public string Amputation { get; set; }
        public string Inspection { get; set; }
        public string FinalNarrative { get; set; }
        public string Nature { get; set; }
        public string NatureTitle { get; set; }
        public string PartofBody { get; set; }
        public string PartofBodyTitle { get; set; }
        public string Event { get; set; }
        public string EventTitle { get; set; }
        public string Source { get; set; }
        public string SourceTitle { get; set; }
        public string SecondarySource { get; set; }
        public string SecondarySourceTitle { get; set; }

    }
}
