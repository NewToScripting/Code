//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ServiceModel.Activation;
using Inspire.Server.ScheduledSlideManager.MessageContracts;
using WCF = global::System.ServiceModel;
using Inspire.Server.ScheduledSlideManager.BusinessLogic;

namespace Inspire.Server.ScheduledSlideManager.ServiceImplementation
{	
	/// <summary>
	/// Service Class - ScheduledSlideManagerService
	/// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[WCF::ServiceBehavior(Name = "ScheduledSlideManagerService", 
		Namespace = "http://schemas.inspiredisplays.com/ServiceContract/", 
		InstanceContextMode = WCF::InstanceContextMode.PerSession, 
		ConcurrencyMode = WCF::ConcurrencyMode.Single )]
	public abstract class ScheduledSlideManagerServiceBase : ServiceContracts.IScheduledSlideManagerServiceContract
	{
		#region ScheduledSlideManagerServiceContract Members

		public virtual GetScheduledSlidesResponseMessage GetScheduledSlides(GetScheduledSlidesRequestMessage request)
		{
            GetScheduledSlidesResponseMessage response = new GetScheduledSlidesResponseMessage();
            response.Schedules = ScheduledSlideAccessFasade.GetScheduledSlides(request.ScheduleID);
            return response;
		}

        public virtual GetScheduledSlidesNoThumbResponseMessage GetScheduledSlidesNoThumb(GetScheduledSlidesNoThumbRequestMessage request)
        {
            GetScheduledSlidesNoThumbResponseMessage response = new GetScheduledSlidesNoThumbResponseMessage();
            response.Schedules = ScheduledSlideAccessFasade.GetScheduledSlidesNoThumb(request.ScheduleID);
            return response;
        }

		public virtual AddScheduledSlideResponseMessage AddScheduledSlide(AddScheduledSlideRequestMessage request)
		{
            ScheduledSlideAccessFasade.AddScheduledSlide(request.ScheduledSlide);
            AddScheduledSlideResponseMessage response = new AddScheduledSlideResponseMessage();
            return response;
		}

		public virtual UpdateScheduleSlidesResponseMessage UpdateScheduleSlides(UpdateScheduleSlidesRequestMessage request)
		{
            ScheduledSlideAccessFasade.UpdatesScheduledSlide(request.ScheduledSlides, request.ScheduledID);
            UpdateScheduleSlidesResponseMessage response = new UpdateScheduleSlidesResponseMessage();
            return response;
		}

		public virtual DeleteScheduledSlideResponseMessage DeleteScheduledSlide(DeleteScheduledSlideRequestMessage request)
        {
            ScheduledSlideAccessFasade.DeleteScheduledSlide(request.ScheduledSlideID);
            DeleteScheduledSlideResponseMessage response = new DeleteScheduledSlideResponseMessage();
            return response;
		}


        public virtual IsSlideScheduledResponseMessage IsSlideScheduled(IsSlideScheduledRequestMessage request)
        {
            IsSlideScheduledResponseMessage response = new IsSlideScheduledResponseMessage();
            response.IsSlideScheduled = ScheduledSlideAccessFasade.IsSlideScheduled(request.SlideID);
            return response;
        }

        public virtual UpdateOriginalSlideIdsResponseMessage UpdateOriginalSlideIds(UpdateOriginalSlideIdsRequestMessage request)
        {   
            UpdateOriginalSlideIdsResponseMessage response = new UpdateOriginalSlideIdsResponseMessage();
            ScheduledSlideAccessFasade.UpdateOriginalSlideIds(request.OriginalSlideID, request.NewSlideID, request.DeleteExistingSlide);
            return response;
        }


        public virtual DeleteSlideNavagationResponseMessage DeleteSlideNavagation(DeleteSlideNavagationRequestMessage request)
        {
            return new DeleteSlideNavagationResponseMessage();
        }

        public virtual AddSlideNavagationResponseMessage AddSlideNavagation(AddSlideNavagationRequestMessage request)
        {
            return new AddSlideNavagationResponseMessage();
        }






		#endregion		
		
	}
	
	public partial class ScheduledSlideManagerService : ScheduledSlideManagerServiceBase
	{
	}
	
}

