using Persistence;
using System.Collections.Generic;

namespace Domain.Infrastructure
{

    public class DropDownData
    {
        private readonly ApplicationDataContext _context;

        public DropDownData(ApplicationDataContext context)
        {
            _context = context;
        }


        public string Text { get; set; }

        public string Value { get; set; }

        public DropDownData()
        {

        }

        public DropDownData(string txt, string val)
        {
            Text = txt;
            Value = val;
        }
        public List<object> GetusertList()
        {
            var userList = new List<object>();

            foreach (var user in _context.Users)
            {
                userList.Add(new { Text = user.FirstName + " " + user.LastName, Value = user.Id });
            }
            return userList;
        }
        
    }
}