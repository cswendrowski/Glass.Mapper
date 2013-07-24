/*
   Copyright 2012 Michael Edwards
 
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 
*/ 
//-CRE-

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;

namespace Glass.Mapper.Sc
{
    /// <summary>
    /// Class ItemEditing
    /// </summary>
    public class ItemEditing : IDisposable
    {
        private Item _item;
        private SecurityDisabler _securityDisabler;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemEditing"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="disableSecurity">if set to <c>true</c> [disable security].</param>
        public ItemEditing(Item item, bool disableSecurity)
        {
            _item = item;
            if (disableSecurity)
                _securityDisabler = new SecurityDisabler();

            _item.Editing.BeginEdit();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _item.Editing.EndEdit();
                _item = null;

                if (_securityDisabler != null)
                {
                    _securityDisabler.Dispose();
                    _securityDisabler = null;
                }
            }
        }
    }
}




