using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Models
{
    public class EFContactInfoRepository : IContactInfoRepository
    {
        private BookstoreContext context;
        public EFContactInfoRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<ContactInfo> ContactInfo => context.ContactInfo.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveContactInfo(ContactInfo ci)
        {
            context.AttachRange(ci.Lines.Select(x => x.Book));

            if (ci.ContactId == 0)
            {
                context.ContactInfo.Add(ci);
            }
            context.SaveChanges();

        }
    }
}
