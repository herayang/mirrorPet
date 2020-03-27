using System;
using System.Collections.Generic;
using System.Text;

namespace mirrorPet.Models
{


	public class Goal : Pet
	{
		private string _goalId;
		private double _goalSum;
		private double _goalTarget;
		private string _goalName;


        public string GoalId
		{
			get
			{
				return this._goalId;
			}
			set
			{
				this._goalId = value;
			}
		}

        public double GoalSum
		{

			get
			{
				return this._goalSum;
			}
			set
			{
				this._goalSum = value;
			}
		}

		public double GoalTarget
		{
			get
			{
				return this._goalTarget;
			}
			set
			{
				this._goalTarget = value;
			}
		}


		public string GoalName
		{
			get
			{
				return this._goalName;
			}
			set
			{
				this._goalName = value;
			}
		}


		public new string PetImageUrl
		{
			get
			{
				return this.PetImageUrl;
			}
			set
			{
				this.PetImageUrl = value;
			}
		}

		public new string PetId
		{
			get
			{
				return this.PetId;
			}
			set
			{
				this.PetId = value;
			}
		}

		public new string PetName
		{
			get
			{
				return this.PetName;
			}
			set
			{
				this.PetName = value;
			}
		}

	}
}
