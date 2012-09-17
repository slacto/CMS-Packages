using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Composite.C1Console.Security;
using Composite.Data;
using Composite.Data.Types;
using System.Xml.Linq;
using Composite.Core.ResourceSystem;

namespace Composite.Tools.PackageCreator.Types
{
	partial class PCFunctions
	{

		public static IEnumerable<IPackageCreatorItem> CreateVisual(EntityToken entityToken)
		{
			if (entityToken is DataEntityToken)
			{
				DataEntityToken dataEntityToken = (DataEntityToken)entityToken;
				if (dataEntityToken.Data is IVisualFunction)
				{
					IVisualFunction data = (IVisualFunction)dataEntityToken.Data;
					yield return new PCFunctions(data.Namespace + "." + data.Name);
				}
			}
		}

		public void PackVisualFunction(PackageCreator pc)
		{
			IVisualFunction visualFunction;
			try
			{
				visualFunction = (from i in DataFacade.GetData<IVisualFunction>()
								  where i.Namespace + "." + i.Name == this.Name
								  select i).First();
			}
			catch (Exception)
			{
				throw new ArgumentException(string.Format(@"Visual Function '{0}' doesn't exists", this.Name));
			}
			pc.AddData(visualFunction);
		}
	}
}