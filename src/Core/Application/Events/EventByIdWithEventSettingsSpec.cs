using EventManagment.Application.Catalog.Products;
using EventManagment.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagment.Application.Events;
public class EventByIdWithEventSettingsSpec : Specification<Event, EventDetailsDto>, ISingleResultSpecification
{
    public EventByIdWithEventSettingsSpec(Guid id) =>
       Query
           .Where(p => p.Id == id)
           .Include(p => p.EventSettings);

}
   
