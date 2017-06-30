//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Inspire.Server.Images.BusinessLogic;
using Inspire.Server.Images.MessageContracts;
using Inspire.Server.Images.ServiceContracts;
using WCF = global::System.ServiceModel;

namespace Inspire.Server.Images.ServiceImplementation
{	
	/// <summary>
	/// Service Class - DirectionService
	/// </summary>
	[WCF::ServiceBehavior(Name = "ImagesService", 
		Namespace = "http://schemas.inspiredisplays.com", 
		InstanceContextMode = WCF::InstanceContextMode.PerSession, 
		ConcurrencyMode = WCF::ConcurrencyMode.Single )]
	public abstract class ImageServiceBase : IImageServiceContract
	{
		#region DirectionServiceContract Members

		public virtual GetImagesResponseMessage GetImages(GetImagesRequestMessage request)
		{
            GetImagesResponseMessage response = new GetImagesResponseMessage();
            response.EventImages = ResouceAccessFasade.GetDirectionalImages(request.Type);
            return response;
		}

        public virtual AddImageResponseMessage AddImage(AddImageRequestMessage request)
        {
            AddImageResponseMessage response = new AddImageResponseMessage();
            response.WebPath = ResouceAccessFasade.AddDirectionalImage(request.DirectionImage, request.ImageFile);
            return response;
        }

        public virtual DeleteImageResponseMessage DeleteImage(DeleteImageRequestMessage request)
        {
            ResouceAccessFasade.DeleteDirectionalImage(request.EventImage);
            return new DeleteImageResponseMessage();
        }

      
		#endregion		
		
	}
	
	public partial class ImageService : ImageServiceBase
	{
	}
	
}

