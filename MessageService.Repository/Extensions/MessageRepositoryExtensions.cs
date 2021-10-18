using MessageService.Entities.Models;
using MessageService.Repository.Extensions.Utility;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace MessageService.Repository.Extensions
{
    public static class MessageRepositoryExtensions
    {
        public static IQueryable<Message> Search(this IQueryable<Message> messages,
            string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return messages;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return messages.Where(c => c.Text.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Message> Sort(this IQueryable<Message> messages,
             string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return messages.OrderBy(e => e.Text);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Message>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return messages.OrderBy(e => e.Text);

            return messages.OrderBy(orderQuery);
        }

        public static IQueryable<Message> FilterByDate(this IQueryable<Message> messages,
            DateTime startDate, DateTime endDate) =>
            messages.Where(p => startDate <= p.SendDate && p.SendDate <= endDate);
    }
}
