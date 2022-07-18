using System.Collections.Generic;
using System.Linq;
using AcademyApi.V1.Boundary.Response;

namespace AcademyApi.V1.UseCase;

public static class Helpers
{
    public static List<NoteResponseObject> ProcessNotes(string[] notes)
    {
        var returnNotes = new List<NoteResponseObject>();
        foreach (var note in notes)
        {
            var rawNote = note.Split('\n').ToArray();

            var metaDataStr = rawNote.Where(s => (s.Contains("User Id: "))).ToList().FirstOrDefault();

            var text = rawNote.Where(s => !string.IsNullOrEmpty(s) && s != metaDataStr).ToArray();

            if (metaDataStr != null)
            {
                var metaData = metaDataStr.Split("Date: ");

                returnNotes.Add(new NoteResponseObject()
                {
                    Note = string.Join("\n", text),
                    UserId = metaData[0].Replace("User Id: ", "").Trim(),
                    Date = metaData[1]
                });
            }
        }

        return returnNotes;
    }
}
