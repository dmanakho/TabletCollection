using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TabletCollection.DAL;

namespace TabletCollection.Infrastructure
{
    public class SingleStudentTabletMapper
    {
        private TabletCollectionDBContext db = new TabletCollectionDBContext();

        public string TabletName { get; }
        public int? TabletID { get; }

        public SingleStudentTabletMapper(string userName)
        {
            try
            {
                var tablet = db.Tablets
                .Where(t => t.TabletName.Contains(getSearchString(userName)))
                .Select(t => new { t.TabletName, t.ID })
                .FirstOrDefault();
                TabletName = tablet.TabletName.ToUpper();
                TabletID = tablet.ID;

            }
            catch (ArgumentNullException)
            {
                TabletName = string.Empty;
                TabletID = null;
            }

        }

        public SingleStudentTabletMapper(int studentID)
        {
            try
            {
                var userName = db.Students
                    .Where(s => s.ID == studentID)
                    .Select(s => s.UserName)
                    .FirstOrDefault()
                    .ToUpper();

                var tablet = db.Tablets
                .Where(t => t.TabletName.Contains(getSearchString(userName)))
                .Select(t => t.TabletName)
                .FirstOrDefault()
                .ToUpper();
                TabletName = tablet;
            }
            catch (ArgumentNullException)
            {
                TabletName = string.Empty;
            }

        }
        private string getSearchString(string searchString)
        {
            return searchString
                .Replace("_", "-")
                .Substring(0, Math.Min(searchString.IndexOf("@"), 10))
                .ToUpper();
        }
    }

    public class StudentTabletMapper
    {
        private TabletCollectionDBContext db = new TabletCollectionDBContext();

        public Dictionary<int, string> _stutablet { get; } = new Dictionary<int, string>();

        public string this[int index]
        {
            get
            {
                return _stutablet[index];
            }
        }

        private List<string> _tablets;

        public StudentTabletMapper()
        {
            var students = db.Students
                .OrderBy(s => s.FirstName)
                .ThenBy(s => s.LastName)
                .Select(s => new { s.UserName, s.ID })
                .ToList();


            _tablets = db.Tablets.Select(t => t.TabletName.ToUpper()).ToList();

            foreach (var student in students)
            {
                var _fragment = getFragment(student.UserName.ToUpper());

                _stutablet.Add(student.ID, getTablet(_fragment));
            }
            Debug.WriteLine(_stutablet);
        }

        private string getTablet(string queryString)
        {
            try
            {
                var tablet = _tablets.Where(t => t.Contains(queryString)).FirstOrDefault();
                return tablet;
            }
            catch (ArgumentNullException)
            {
                return string.Empty;
            }
        }
        private string getFragment(string userName)
        {
            return userName
                .Replace("_", "-")
                .Substring(0, Math.Min(userName.IndexOf("@"), 10));
        }

    }


}