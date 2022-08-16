using System;

namespace AcademyApi.V1.Boundary.Response
{
    //Guidance on XML comments and response objects here (https://github.com/LBHackney-IT/lbh-base-api/wiki/Controllers-and-Response-Objects)

    public class NoteResponseObject
    {
        public string Date { get; set; }
        public string UserId { get; set; }
        public string Note { get; set; }
    }
}
