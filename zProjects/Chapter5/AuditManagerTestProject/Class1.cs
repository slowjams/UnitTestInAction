using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditManagerTestProject {

   public class AuditManager {
      private readonly int _maxEntriesPerFile;
      private readonly string _directoryName;

      public AuditManager(int maxEntriesPerFile, string directoryName) {
         _maxEntriesPerFile = maxEntriesPerFile;
         _directoryName = directoryName;
      }

      public void AddRecord(string visitorName, DateTime timeOfVisit) {
         IEnumerable<string> s;
         s.OrderBy
      }
   }

   public interface IFileSystem {
      string[] GetFiles(string directoryName);
      void WriteAllText(string filePath, string content);
      List<string> ReadAllLines(string filePath);
   }
}
