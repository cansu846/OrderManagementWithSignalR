﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Pages
{
	public class SocialMedia
	{
		public int SocialMediaID { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }
		public string Icon { get; set; }
	}
}
