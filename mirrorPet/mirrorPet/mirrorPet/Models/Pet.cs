using System;
namespace mirrorPet.Models
{
	public class Pet
	{
		private string _petId;
        private string _petImageUrl;
		private string _petName;
		
		public string PetId
		{
			get
			{
				return this._petId;
			}
			set
			{
				this._petId = value;
			}
		}


		public string PetImageUrl
		{
			get
			{
				return this._petImageUrl;
			}
			set
			{
				this._petImageUrl = value;
			}
		}

		public string PetName
		{
			get
			{
				return this._petName;
			}
			set
			{
				this._petName = value;
			}
		}

	}

}