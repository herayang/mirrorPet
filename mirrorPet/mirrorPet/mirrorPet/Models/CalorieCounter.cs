using System;
using System.Collections.Generic;
using System.Text;

namespace mirrorPet.Models
{
	

	class CalorieCounter
	{
		private int _calorieSum;
		private int _goal; 
		private String _status = "N/A"; 

		public int CalorieSum {

			get {
				return this._calorieSum;
			}
			set {
				this._calorieSum = value; 
			}
		}

		public int Goal {
			get {
				return this._goal; 
			}
			set {
				this._goal = value; 
			}
		}

		public String Status {

			get {
				return this._status;
			}
		}
		/**
		 * Adds consumed calories to the current calorie sum. 
		 */ 
		public void addCalorie(int consumed) {
			this._calorieSum += consumed; 
		}
		/**
		 * resets the current cal orie sum to zero. 
		 */
		public void resetSum() {
			this._calorieSum = 0; 
		}

		/**
		 * Compares calorieSum and goal and returns if the goal is met. 
		 * returns achieved when met perfectly.
		 * returns "under" when goal is not met. 
		 * returns "over" when caloriesum exceeds goal. 
		 * */
		public String statusCheck() {
			if (this._goal == this._calorieSum)
			{
				return "achieved";
			}
			else if (this._goal > this._calorieSum)
			{
				return "over";
			}
			else {
				return "under";
			}

		}
		
	}
}
