using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


interface IJointPositionUpdater<T>   
{
    void UpdateJoints(IEnumerable<T> joints);
} 
  