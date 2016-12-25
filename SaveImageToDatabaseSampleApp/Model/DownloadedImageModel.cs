﻿using System;
using System.IO;
using System.Diagnostics;

using SQLite;

using Xamarin.Forms;

namespace SaveImageToDatabaseSampleApp
{
	public class DownloadedImageModel
	{
		[PrimaryKey]
		public string ImageUrl { get; set;}

		public string PuzzleImageAsBase64String { get; set; }

		public ImageSource DownloadedImageAsImageStreamFromBase64String
		{
			get
			{
				try
				{
					if (PuzzleImageAsBase64String == null)
					{
						return null;
					}

					var imageString = PuzzleImageAsBase64String;
					var imageByteArray = Convert.FromBase64String(imageString);

					return ImageSource.FromStream(() => new MemoryStream(imageByteArray));
				}
				catch (Exception e)
				{
					Debug.WriteLine(e);
					return null;
				}
			}
		}
	}
}